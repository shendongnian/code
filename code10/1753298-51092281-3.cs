    using System.IO;
    using System;
    using System.Linq;
    using YamlDotNet.Serialization;
    using System.Collections.Generic;
    
    namespace ConsoleApp1
    {
        public class Program
        {
            public static void Main()
            {
                object yamlObject;
                using (var r = new StringReader(Program.Document))
                    yamlObject = new Deserializer().Deserialize(r);
    
                var data = new YamlQuery(yamlObject)
                                    .On("pods")
                                    .Get("name")
                                    .ToList<string>();
    
                Console.WriteLine(string.Join(",", data));
            }
    
            public class YamlQuery
            {
                private object yamlDic;
                private string key;
                private object current;
    
                public YamlQuery(object yamlDic)
                {
                    this.yamlDic = yamlDic;
                }
    
                public YamlQuery On(string key)
                {
                    this.key = key;
                    this.current = query<object>(this.current ?? this.yamlDic, this.key, null);
                    return this;
                }
    
                public YamlQuery Get(string prop)
                {
                    if (this.current == null)
                        throw new InvalidOperationException();
    
                    this.current = query<object>(this.current, null, prop, this.key);
                    return this;
                }
    
                public List<T> ToList<T>()
                {
                    if (this.current == null)
                        throw new InvalidOperationException();
    
                    return (this.current as List<object>).Cast<T>().ToList();
                }
    
    
                private IEnumerable<T> query<T>(object _dic, string key, string prop, string fromKey = null)
                {
                    var result = new List<T>();
                    if (_dic == null)
                        return result;
                    if (typeof(IDictionary<object, object>).IsAssignableFrom(_dic.GetType()))
                    {
                        var dic = (IDictionary<object, object>)_dic;
                        var d = dic.Cast<KeyValuePair<object, object>>();
    
                        foreach (var dd in d)
                        {
                            if (dd.Key as string == key)
                            {
                                if (prop == null)
                                { 
                                    result.Add((T)dd.Value);
                                } else
                                { 
                                    result.AddRange(query<T>(dd.Value, key, prop, dd.Key as string));
                                }
                            }
                            else if (fromKey == key && dd.Key as string == prop)
                            { 
                                result.Add((T)dd.Value);
                            }
                            else
                            { 
                                result.AddRange(query<T>(dd.Value, key, prop, dd.Key as string));
                            }
                        }
                    }
                    else if (typeof(IEnumerable<object>).IsAssignableFrom(_dic.GetType()))
                    {
                        var t = (IEnumerable<object>)_dic;
                        foreach (var tt in t)
                        {
                            result.AddRange(query<T>(tt, key, prop, key));
                        }
    
                    }
                    return result;
                }
            }
    
    
    
    
            private const string Document = @"---
                receipt:    Oz-Ware Purchase Invoice
                date:        2007-08-06
                customer:
                    given:   Dorothy
                    family:  Gale
    
                pods:
                    - name:   pod1
                      descrip:   Water Bucket (Filled)
                      price:     1.47
                      quantity:  4
                      
    
                    - name:   pod2
                      descrip:   High Heeled ""Ruby"" Slippers
                      price:     100.27
                      quantity:  1
    
                bill-to:  &id001
                    street: |-
                            123 Tornado Alley
                            Suite 16
                    city:   East Westville
                    state:  KS
                    pods:
                        - name: pod3
                          descrip:   High Heeled ""Ruby"" Slippers
                          price:     100.27
                          quantity:  1
                         
                specialDelivery: >
                    Follow the Yellow Brick
                    Road to the Emerald City.
                    Pay no attention to the
                    man behind the curtain.
    ...";
        }
    
    }

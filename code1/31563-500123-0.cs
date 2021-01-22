    using System;
    using System.Collections.Generic;
    
    namespace Program
    {
        class Program
        {
            static void Main(string[] args)
            {
                MyList<int> list = new MyList<int>();
                // Add a property with setter.
                list["One"] = 1;
                // Add a property with getter which takes default value.
                int two = list["Two", 2];
                Console.WriteLine("One={0}", list["One"]);
                Console.WriteLine("Two={0} / {1}", two, list["Two"]);
                try
                {
                    Console.WriteLine("Three={0}", list["Three"]);
                }
                catch
                {
                    Console.WriteLine("Three does not exist.");
                }
            }
            class MyList<T>
            {
                Dictionary<string, T> dictionary = new Dictionary<string,T>();
    
                internal T this[string property, T def]
                {
                    get
                    {
                        T value;
                        if (!dictionary.TryGetValue(property, out value))
                            dictionary.Add(property, value = def);
                        return value;
                    }
                }
                internal T this[string property]
                {
                    get
                    {
                        return dictionary[property];
                    }
                    set
                    {
                        dictionary[property] = value;
                    }
                }
            }
        }
    }

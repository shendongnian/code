    /*
     * Denis Bekman 2009
     * www.youpvp.com/blog
     --
     * This code is licensed under a Creative Commons Attribution 3.0 United States License.
     * To view a copy of this license, visit http://creativecommons.org/licenses/by/3.0/us/
     */
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Xml;
    using System.Net;
    namespace YouPVP
    {
        public class LuaParse
        {
            List<string> toks = new List<string>();
            public string Id { get; set; }
            public LuaObject Val { get; set; }
            public void Parse(string s)
            {
                string qs = string.Format("({0}[^{0}]*{0})", "\"");
                string[] z = Regex.Split(s, qs + @"|(=)|(,)|(\[)|(\])|(\{)|(\})|(--[^\n\r]*)");
                foreach (string tok in z)
                {
                    if (tok.Trim().Length != 0 && !tok.StartsWith("--"))
                    {
                        toks.Add(tok.Trim());
                    }
                }
                Assign();
            }
            protected void Assign()
            {
                if (!IsLiteral)
                    throw new Exception("expect identifier");
                Id = GetToken();
                if (!IsToken("="))
                    throw new Exception("expect '='");
                NextToken();
                Val = RVal();
            }
            protected LuaObject RVal()
            {
                if (IsToken("{"))
                    return LuaObject();
                else if (IsString)
                    return GetString();
                else if (IsNumber)
                    return GetNumber();
                else if (IsFloat)
                    return GetFloat();
                else
                    throw new Exception("expecting '{', a string or a number");
            }
            protected LuaObject LuaObject()
            {
                Dictionary<string, LuaObject> table = new Dictionary<string, LuaObject>();
                NextToken();
                while (!IsToken("}"))
                {
                    if (IsToken("["))
                    {
                        NextToken();
                        string name = GetString();
                        if (!IsToken("]"))
                            throw new Exception("expecting ']'");
                        NextToken();
                        if (!IsToken("="))
                            throw new Exception("expecting '='");
                        NextToken();
                        table.Add(name, RVal());
                    }
                    else
                    {
                        table.Add(table.Count.ToString(), RVal());//array
                    }
                    if (!IsToken(","))
                        throw new Exception("expecting ','");
                    NextToken();
                }
                NextToken();
                return table;
            }
            protected bool IsLiteral
            {
                get
                {
                    return Regex.IsMatch(toks[0], "^[a-zA-Z]+[0-9a-zA-Z_]*");
                }
            }
            protected bool IsString
            {
                get
                {
                    return Regex.IsMatch(toks[0], "^\"([^\"]*)\"");
                }
            }
            protected bool IsNumber
            {
                get
                {
                    return Regex.IsMatch(toks[0], @"^\d+");
                }
            }
            protected bool IsFloat
            {
                get
                {
                    return Regex.IsMatch(toks[0], @"^\d*\.\d+");
                }
            }
            protected string GetToken()
            {
                string v = toks[0];
                toks.RemoveAt(0);
                return v;
            }
            protected LuaObject GetString()
            {
                Match m = Regex.Match(toks[0], "^\"([^\"]*)\"");
                string v = m.Groups[1].Captures[0].Value;
                toks.RemoveAt(0);
                return v;
            }
            protected LuaObject GetNumber()
            {
                int v = Convert.ToInt32(toks[0]);
                toks.RemoveAt(0);
                return v;
            }
            protected LuaObject GetFloat()
            {
                double v = Convert.ToDouble(toks[0]);
                toks.RemoveAt(0);
                return v;
            }
            protected void NextToken()
            {
                toks.RemoveAt(0);
            }
            protected bool IsToken(string s)
            {
                return toks[0] == s;
            }
        }
        public class LuaObject : System.Collections.IEnumerable
        {
            private object luaobj;
            public LuaObject(object o)
            {
                luaobj = o;
            }
            public System.Collections.IEnumerator GetEnumerator()
            {
                Dictionary<string, LuaObject> dic = luaobj as Dictionary<string, LuaObject>;
                return dic.GetEnumerator();
            }
            public LuaObject this[int ix]
            {
                get
                {
                    Dictionary<string, LuaObject> dic = luaobj as Dictionary<string, LuaObject>;
                    try
                    {
                        return dic[ix.ToString()];
                    }
                    catch (KeyNotFoundException)
                    {
                        return null;
                    }
                }
            }
            public LuaObject this[string index]
            {
                get
                {
                    Dictionary<string, LuaObject> dic = luaobj as Dictionary<string, LuaObject>;
                    try
                    {
                        return dic[index];
                    }
                    catch (KeyNotFoundException)
                    {
                        return null;
                    }
                }
            }
            public static implicit operator string(LuaObject m)
            {
                return m.luaobj as string;
            }
            public static implicit operator int(LuaObject m)
            {
                return (m.luaobj as int? ?? 0);
            }
            public static implicit operator LuaObject(string s)
            {
                return new LuaObject(s);
            }
            public static implicit operator LuaObject(int i)
            {
                return new LuaObject(i);
            }
            public static implicit operator LuaObject(double d)
            {
                return new LuaObject(d);
            }
            public static implicit operator LuaObject(Dictionary<string, LuaObject> dic)
            {
                return new LuaObject(dic);
            }
        }
    }

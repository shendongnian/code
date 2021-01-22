    class Program
    {
        static void Main(string[] args)
        {
            dynamic userDynamic = new JsonUser();
            Console.WriteLine(IsPropertyExist(() => userDynamic.first_name));
            Console.WriteLine(IsPropertyExist(() => userDynamic.address));
            Console.WriteLine(IsPropertyExist(() => userDynamic.last_name));
        }
        class JsonUser
        {
            public string first_name { get; set; }
            public string address
            {
                get
                {
                    throw new InvalidOperationException("Cannot read property value");
                }
            }
        }
        static bool IsPropertyExist(GetValueDelegate getValueMethod)
        {
            try
            {
                //we're not interesting in the return value. What we need to know is whether an exception occurred or not
                getValueMethod();
                return true;
            }
            catch (RuntimeBinderException)
            {
                // RuntimeBinderException occurred during accessing the property
                // and it means there is no such property         
                return false;
            }
            catch
            {
                //property exists, but an exception occurred during getting of a value
                return true;
            }
        }
        delegate string GetValueDelegate();
    }

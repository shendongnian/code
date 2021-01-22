        static void Main(string[] args)
        {
            string format = "#";
            DateTime myDate = DateTime.Now;
            if (myDate.ValidateFormat(format))
                Console.WriteLine(myDate.ToString(format));
            else
                Console.WriteLine("Bad format");
            Console.ReadLine();
        }
        static bool ValidateFormat(this object obj, string format)
        {
            try
            {
                MethodInfo info = obj.GetType().GetMethod("ToString", new Type[] { format.GetType() });
                if (info == null)
                    return false;
                info.Invoke(obj, new object[] { format });
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

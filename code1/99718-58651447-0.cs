    bool exceptionthrow = false;
            while (!exceptionthrow)
            {
                try
                {
                    value = Convert.ToInt32(Console.ReadLine()); //example
                    exceptionthrow = true;
                }
                catch (Exception)
                {
                    exceptionthrow = false;
                    continue;
                }
            }

             protected override void myMethod<T>(List<T> myList)
            {
                if (typeof(T) == typeof(DateTime))
                { 
                    //this is a List<DateTime>
                    var list = (IList<DateTime>)myList;
                    String str = list[0].ToString("yyyy");
                }
                else if(typeof(T) == typeof(String))
                {
                    //this is a List<String>
                }
                else
                {
                    //.....Other classes
                }
            }
            void test()
            {
                myMethod<String>(new List<String>());//this will access the "else if" part
            }

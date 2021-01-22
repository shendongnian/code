    public static void Main(string[] args)
        {
            
             
          List<CarSpecs> list = new List<CarSpecs>();
          list.Add(new CarSpecs("Focus", "Ford", new DateTime(2010,1, 2));
          list.Add(new CarSpecs("Prius", "Toyota", new DateTime(2012,3, 3));
          list.Add(new CarSpecs("Ram", "Dodge", new DateTime(2013, 10, 6));
          
            
            list.Sort(delegate (CarSpecs first, CarSpecs second)
            {
                int returnValue = 1;
                if((first != null & second != null))
                {
                    if (first.CarName.Equals(second.CarName))
                    {
                        if (first.CarMaker.Equals(second.CarMaker))
                        {
                        returnValue = first.CreationDate.CompareTo(second.CreationDate);
                        }
                        else
                        {
                        returnValue = first.CarMaker.CompareTo(second.CarMaker);
                        }
                    }
                    else
                    {
                        returnValue = first.CarName.CompareTo(second.CarName);
                    }
                }
                return returnValue;
            });
        }

            SortedList<DateTime,Control> sl = new SortedList<DateTime,Control>();
            foreach (Control i in mainContent.Controls)
            {
                if (i.GetType().BaseType == typeof(MyBaseType))
                {
                    MyBaseType iTyped = (MyBaseType)i;
                    sl.Add(iTyped.Date, iTyped);
                }
            }
            
            foreach (MyBaseType j in sl.Values)
            {
                j.SendToBack();
            }
            

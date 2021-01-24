    namespace xy
    {
      class test
      {
        List<bool> slots = new List<bool>();
        DateTime start;
        DateTime end;
        
        public test(DateTime start, DateTime end)
        {
            this.start = start;
            this.end = end;
            for(int i=1; i <= (end.Hour * 60) + end.Minute; i++)
            {
                slots.Add(true);
            }
        }
        public void Block_Slots(DateTime startBlock, DateTime endBlock)
        {
            for(int i = (startBlock.Hour * 60) + startBlock.Minute; i<= (endBlock.Hour * 60) + endBlock.Minute; i++)
            {
                slots[i] = false;
            }
        }
        public List<Slot> GetFreeSlots()
        {
            List<Slot> tmp = new List<Slot>();
            Nullable<DateTime> startPeriod = null;
            Nullable<DateTime> endPeriod = null;
            int counter = 1;
            foreach(bool entry in slots)
            {
                if (entry)
                {
                    if(startPeriod == null)
                        startPeriod = new DateTime(this.start.Year, this.start.Month, this.start.Day, counter / 60 + start.Hour, counter % 60 + start.Minute, 0);
                    else
                    {
                      
                        
                    }
                       
                }
                else
                {
                    if(startPeriod != null)
                    {
                        endPeriod = new DateTime(this.start.Year, this.start.Month, this.start.Day, counter-1 / 60, counter-1 % 60, 0);
                        tmp.Add(new Slot((DateTime)startPeriod, (DateTime)endPeriod));
                        startPeriod = null;
                        endPeriod = null;
                        
                        
                    }else{}
                }
                counter++;
            }
            return tmp;
        }
      
    }
    class Slot
    {
        DateTime start;
        DateTime end;
        public Slot(DateTime start, DateTime end)
        {
            this.start = start;
            this.end = end;
        }
    }
    }

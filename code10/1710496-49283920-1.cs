    List<SegmentList> li = new List<SegmentList>();
                li.Add(new SegmentList { Segname = "Select", SegId = 0 });
                li.Add(new SegmentList { Segname = "Allergy", SegId = 1 });
                li.Add(new SegmentList { Segname = "Skin", SegId = 2 });
                li.Add(new SegmentList { Segname = "Hair", SegId = 3 });
                li.Add(new SegmentList { Segname = "Fever", SegId = 4 });
                li.Add(new SegmentList { Segname = "All", SegId = 5 });
    
                List<string> stringList = new List<string>("Allergy,Skin,Cured,Better".Split(',')) ;
    
                foreach(var stirng in stringList)
                {
                    if(li.Any(x => x.Segname.Equals(stirng)))
                    {
                        li.Add(new SegmentList { Segname = stirng, SegId = li.Count });
                    }
                }

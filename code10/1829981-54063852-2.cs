            private static List<ProjectDetail> MockProjectItems()
        {
            var items = new List<ProjectDetail>(20);
            for(int i = 0; i < 20 ; i += 4){
                items.Add(new ProjectDetail{Id = i, Name = "RandomName "+i, Status = "Slow"});
                items.Add(new ProjectDetail{Id = i+1, Name = "RandomName "+(i+1), Status = "Normal"});
                items.Add(new ProjectDetail{Id = i+2, Name = "RandomName "+(i+2), Status = "Fast"});
                items.Add(new ProjectDetail{Id = i+3, Name = "RandomName "+(i+3), Status = "Suspended"});
            }
            return items;
        }

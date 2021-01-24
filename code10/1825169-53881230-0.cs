        Hello you can try this, 
        private void button3_Click(object sender, EventArgs e)
        {
            List<ClassTemp> tempList = new List<ClassTemp>();
            tempList.Add(new ClassTemp() {Name= "Name_1", Value = 100});
            tempList.Add(new ClassTemp() { Name = "Name_1", Value = 180});
            tempList.Add(new ClassTemp() { Name = "Name_1", Value = 500});
            tempList.Add(new ClassTemp() { Name = "Name_2", Value = 40});
            tempList.Add(new ClassTemp() { Name = "Name_2", Value = 150});
            var GroupList = tempList.GroupBy(x => x.Name).Select(grp => new { Name = grp.Key, MaxValue = grp.Max(x => x.Value) }).ToList();
            int totalValue = GroupList.Sum(x => x.MaxValue);
            
        }
        public class ClassTemp
        {
            public string Name;
            public int Value;
        }

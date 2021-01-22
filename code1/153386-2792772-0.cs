    class AnalysisProjectHours : IProjectHours {
        public void SetHours(IEnumerable<Project> projects) {
           projects.Where(p => p.Type == TaskType.Analysis)
                   .Each(p => p.NumberOfHours += 30);
        }
    }
    class WritingProjectHours : IProjectHours {
        public void SetHours(IEnumerable<Project> projects) {
           projects.Where(p => p.Type == TaskType.Writing)
                   .Skip(0).Take(2).Each(p => p.NumberOfHours += 30);
           projects.Where(p => p.Type == TaskType.Writing)
                   .Skip(2).Take(6).Each(p => p.NumberOfHours += 20);
           projects.Where(p => p.Type == TaskType.Writing)
                   .Skip(8).Each(p => p.NumberOfHours += 10);
        }
    }
    class NewProjectHours : IProjectHours {
        public void SetHours(IEnumerable<Project> projects) {
           projects.Where(p => p.Id == null).Each(p => p.NumberOfHours += 5);
        }
    }
    

    class AnalysisProjectHours : IProjectHours {
        public void SetHours(IEnumerable<Project> projects) {
           projects.Where(p => p.Type == TaskType.Analysis)
                   .Each(p => p.NumberOfHours += 30);
        }
    }
    // Non-LINQ equivalent
    class AnalysisProjectHours : IProjectHours {
        public void SetHours(IEnumerable<Project> projects) {
           foreach (Project p in projects) {
              if (p.Type == TaskType.Analysis) {
                 p.NumberOfHours += 30;
              }
           }
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
    // Non-LINQ equivalent
    class WritingProjectHours : IProjectHours {
        public void SetHours(IEnumerable<Project> projects) {
           int writingProjectsCount = 0;
           foreach (Project p in projects) {
              if (p.Type != TaskType.Writing) {
                 continue;
              }
              writingProjectsCount++;
              switch (writingProjectsCount) {
                  case 1: case 2:
                    p.NumberOfHours += 30;
                    break;
                  case 3: case 4: case 5: case 6: case 7: case 8:
                    p.NumberOfHours += 20;
                    break;
                  default:
                    p.NumberOfHours += 10;
                    break;
              }
           }
        }
    }
    class NewProjectHours : IProjectHours {
        public void SetHours(IEnumerable<Project> projects) {
           projects.Where(p => p.Id == null).Each(p => p.NumberOfHours += 5);
        }
    }
    // Non-LINQ equivalent
    class NewProjectHours : IProjectHours {
        public void SetHours(IEnumerable<Project> projects) {
           foreach (Project p in projects) {
              if (p.Id == null) {
                // Add 5 additional hours to each new project
                p.NumberOfHours += 5; 
              }
           }
        }
    }    

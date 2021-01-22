    public abstract class BusinessObject {
        public Guid Guid { get; set; }
    }
    class Area : BusinessObject {
        public string Name { get; set; }
        static void Main() {
            Guid guid = Guid.NewGuid();
            List<Area> areas = new List<Area> {
                new Area { Name = "a", Guid = Guid.NewGuid() },
                new Area { Name = "b", Guid = guid },
                new Area { Name = "c", Guid = Guid.NewGuid() },
            };
            List<Area> allocatedAreas = new List<Area> {
                new Area { Name = "b", Guid = guid},
                new Area { Name = "d", Guid = Guid.NewGuid()},
            };
            BusinessObjectGuidEqualityComparer<Area> comparer =
                 new BusinessObjectGuidEqualityComparer<Area>();
            IEnumerable<Area> toRemove = areas.Except(allocatedAreas, comparer);
            foreach (var row in toRemove) {
                Console.WriteLine(row.Name); // shows a & c, since b is allocated
            }
        }
    }

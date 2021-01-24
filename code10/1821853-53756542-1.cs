    class EquipmentParser {
        public IList<Equipment> Parse(string[] input) {
            var result = new List<Equipment>();
            var header = input[0].Split(',').Select(t => t.Trim().ToLower()).ToList();
            var standardPosition = GetIndexOf(header, "std", "standard", "st");
            var namePosition = GetIndexOf(header, "name", "nm");
            var efficiencyPosition = GetIndexOf(header, "efficiency", "eff");
            foreach (var s in input.Skip(1)) {
                var line = s.Split(',');
                result.Add(new Equipment {
                    Standard = line[standardPosition].Trim(),
                    Name = line[namePosition].Trim(),
                    Efficiency = int.Parse(line[efficiencyPosition])
                });
            }
            return result;
        }
        private int GetIndexOf(IList<string> input, params string[] needles) {
            return Array.FindIndex(input.ToArray(), needles.Contains);
        }
    }

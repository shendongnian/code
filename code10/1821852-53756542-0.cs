    class EquipmentParser {
        public IList<Equipment> Parse(string[] input) {
            var result = new List<Equipment>();
            var header = input[0].Split(',').Select(t => t.Trim()).ToList();
            var standardPosition = header.IndexOf("STANDARD");
            var namePosition = header.IndexOf("NAME");
            var efficiencyPosition = header.IndexOf("EFFICIENCY");
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
    }

        public string GetCsv(Func<string> getter)
        {
            var buffer = new StringBuilder();
            foreach (var cb in SelectedCheckBoxes)
            {
                buffer.Append(getter()).Append(",");
            }
            return DropLastComma(buffer.ToString());
        }

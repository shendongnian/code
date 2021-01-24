        public static string MaskNames(string input)
        {
            var names = input.Split(new[] { "Dear ", ", Thank you for coming" }, StringSplitOptions.RemoveEmptyEntries).First().Split(' ').ToList();
            string stringToReplace = names.Any() ? string.Join(" ", names.Take(names.Count - 1)) : null;
            if (!string.IsNullOrEmpty(stringToReplace))
            {
                var maskedNameStr = string.Join(" ", names.Take(names.Count - 1).Select(s => new string('*', s.Length)));
                return input.Replace(stringToReplace, maskedNameStr);
            }
            return input;
        }

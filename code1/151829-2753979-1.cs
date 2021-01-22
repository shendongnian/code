        private static readonly Tuple<string, string>[] SpecialUas =
            {
                Tuple.Create("X-OperaMini-Phone-UA", "NOVARRA"),
                Tuple.Create("X-Device-User-Agent", "OPERAMINI")
            };
        public static string GetUa(HttpRequest r)
        {
            return (
                       from specialUa in SpecialUas
                       let serverVariable = r.ServerVariables[specialUa.Item1]
                       where !string.IsNullOrEmpty(serverVariable)
                       select string.Concat(specialUa.Item2, " ", serverVariable)
                   ).FirstOrDefault() ?? (
                       string.IsNullOrEmpty(r.UserAgent)
                       ? "No UA Found"
                       : r.UserAgent
                   );
        }

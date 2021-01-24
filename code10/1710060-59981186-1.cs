        public static string ATextoYYMMDD(this DateTime fechaHora) {
            var chars = new char[6];
            var valor = fechaHora.Year % 100;
            chars[0] = (char)(valor / 10 + '0');
            chars[1] = (char)(valor % 10 + '0');
            valor = fechaHora.Month;
            chars[2] = (char)(valor / 10 + '0');
            chars[3] = (char)(valor % 10 + '0');
            valor = fechaHora.Day;
            chars[4] = (char)(valor / 10 + '0');
            chars[5] = (char)(valor % 10 + '0');
            return new string(chars);
        } 
        public static DateTime AFechaYYMMDD(this string s)
            => new DateTime((s[0] - '0') * 10 + s[1] - '0' + 2000, 
            (s[2] - '0') * 10 + s[3] - '0', (s[4] - '0') * 10 + s[5] - '0');

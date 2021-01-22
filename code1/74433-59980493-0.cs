        public static string ATextoyyMMdd(this DateTime fechaHora) {
            var chars = new char[6];
            int valor = fechaHora.Year % 100;     
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

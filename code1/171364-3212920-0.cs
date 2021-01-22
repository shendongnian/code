    public static class TensaoExtensions {
        public static double TensaoNominal(this Tensao tensao) {
            return Math.Round((double.Parse(EnumMapper.Convert(typeof(Tensao), tensao.ToString()))) * 1000 / Math.Sqrt(3), 3);
        }
    } 

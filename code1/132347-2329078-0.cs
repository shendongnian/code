    static class Converters{
        static Dictionary<Type, Func<string, object>> Converters = new ...
        static Converters{
            Converters.Add(typeof(string), input => input);
            Converters.Add(typeof(int), input => int.Parse(input));
            Converters.Add(typeof(double), double => double.Parse(input));
        }
    }
    void FillDataRow(IList<string> rowInput, row){
        for(int i = 0; i < rowInput.Length; i++){
           var converter = Converters.Converters[Column[i].DataType];
           row[i] = converter(rowInput[i])
        }
    }

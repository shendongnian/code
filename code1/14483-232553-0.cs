    static object[] GetColumn(string[][] source, int col) {
        return source.Iterate().Select(x => source[x.Index][col]).Cast<object>().ToArray();
    }
    static object[] GetRow(string[][] source, int row) {
        return source.Skip(row).First().Cast<object>().ToArray();
    }
    public class Pair<T> {
        public int Index;
        public T Value;
        public Pair(int i, T v) {
            Index = i;
            Value = v;
        }
    }
    static IEnumerable<Pair<T>> Iterate<T>(this IEnumerable<T> source) {
        int index = 0;
        foreach (var cur in source) {
            yield return new Pair<T>(index, cur);
            index++;
        }
    }

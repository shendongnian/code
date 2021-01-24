public static IEnumerable&lt;T&gt; Where(this IEnumerable&lt;T&gt; data, Funct&lt;T, int, bool&gt; p) {
    int i = 0;
    foreach(T t in data) {
        if(p(t, i)) {
            yield return t;
        }
        <b>i++;</b>
    }
}

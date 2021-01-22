    public static void AddOnUI<T>(this ICollection<T> collection, T item) {
        Action<T> addMethod = collection.Add;
        Application.Current.Dispatcher.BeginInvoke( addMethod, item );
    }
    ...
    b_subcollection.AddOnUI(new B());

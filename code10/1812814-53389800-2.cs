    public static class ViewExtensions
    {
        // Enables compilers to dynamically attach object fields to managed objects.
        // https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.conditionalweaktable-2?view=xamarinandroid-7.1
        static readonly ConditionalWeakTable<View, ViewFieldsObject> ViewFields = new ConditionalWeakTable<View, ViewFieldsObject>();
        public static string GetPerson(this View view) { return ViewFields.GetOrCreateValue(view).Person; }
        public static void SetPerson(this View view, string person) { ViewFields.GetOrCreateValue(view).Person = person; }
        public class ViewFieldsObject
        {
            public string Person { get; set; }
        }
    }

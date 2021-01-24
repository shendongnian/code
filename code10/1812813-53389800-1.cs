    public static class ViewExtension
    {
        // Enables compilers to dynamically attach object fields to managed objects.
        // https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.conditionalweaktable-2?view=xamarinandroid-7.1
        static readonly ConditionalWeakTable<View, StringObject> ViewStringFields = new ConditionalWeakTable<View, StringObject>();
        public static string GetPerson(this View view) { return ViewStringFields.GetOrCreateValue(view).Value; }
        public static void SetPerson(this View view, string person) { ViewStringFields.GetOrCreateValue(view).Value = person; }
        public class StringObject
        {
            public string Value;
        }
    }

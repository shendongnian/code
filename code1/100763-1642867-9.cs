    class Program {
        static void Main() {
            // List-based example.
            var listWrapper = new MyClass<BazAndListOfWrgl>(new List<BazAndListOfWrgl>());
            listWrapper.Store(new BazAndListOfWrgl());
            Console.WriteLine(listWrapper.Items.Count);
            // Dictionary-based example.
            var dictionaryWrapper = new MyClass<OuterDictionaryItem>(new OuterDictionary());
            dictionaryWrapper.Store(new OuterDictionaryItem(new Foo(), new BazAndListOfWrglDictionary()));
            Console.WriteLine(dictionaryWrapper.Items.Count);
        }
    }

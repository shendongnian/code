    internal class Program {
        private static void Main(string[] args) {
            var directory = new RAMDirectory();
            var writer = new IndexWriter(directory, new StandardAnalyzer());
            AddDocument(writer, "group", "stuff", Field.Index.UN_TOKENIZED);
            AddDocument(writer, "group", "other stuff", Field.Index.UN_TOKENIZED);
            writer.Close(true);
            var searcher = new IndexSearcher(directory);
            Hits hits = searcher.Search(new TermQuery(new Term("group", "stuff")));
            for (int i = 0; i < hits.Length(); i++) {
                Console.WriteLine(hits.Doc(i).GetField("group").StringValue());
            }
        }
        private static void AddDocument(IndexWriter writer, string name, string value, Field.Index index) {
            var document = new Document();
            document.Add(new Field(name, value, Field.Store.YES, index));
            writer.AddDocument(document);
        }
    }

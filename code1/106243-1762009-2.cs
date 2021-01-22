        private static void Main(string[] args) {
            var directory = new RAMDirectory();
            var writer = new IndexWriter(directory, new StandardAnalyzer());
            var documentA = new Document();
            documentA.Add(new Field("name", "A", Field.Store.YES, Field.Index.UN_TOKENIZED));
            documentA.Add(new Field("group", "stuff", Field.Store.YES, Field.Index.UN_TOKENIZED));
            documentA.Add(new Field("group", "other stuff", Field.Store.YES, Field.Index.UN_TOKENIZED));
            writer.AddDocument(documentA);
            var documentB = new Document();
            documentB.Add(new Field("name", "B", Field.Store.YES, Field.Index.UN_TOKENIZED));
            documentB.Add(new Field("group", "stuff", Field.Store.YES, Field.Index.UN_TOKENIZED));
            writer.AddDocument(documentB);
            var documentC = new Document();
            documentC.Add(new Field("name", "C", Field.Store.YES, Field.Index.UN_TOKENIZED));
            documentC.Add(new Field("group", "other stuff", Field.Store.YES, Field.Index.UN_TOKENIZED));
            writer.AddDocument(documentC);
            writer.Close(true);
            var query1 = new TermQuery(new Term("group", "stuff"));
            SearchAndDisplay("First sample", directory, query1);
            var query2 = new TermQuery(new Term("group", "other stuff"));
            SearchAndDisplay("Second sample", directory, query2);
            var query3 = new BooleanQuery();
            query3.Add(new TermQuery(new Term("group", "stuff")), BooleanClause.Occur.MUST);
            query3.Add(new TermQuery(new Term("group", "other stuff")), BooleanClause.Occur.MUST);
            SearchAndDisplay("Third sample", directory, query3);
        }
        private static void SearchAndDisplay(string title, Directory directory, Query query3) {
            var searcher = new IndexSearcher(directory);
            Hits hits = searcher.Search(query3);
            Console.WriteLine(title);
            for (int i = 0; i < hits.Length(); i++) {
                Console.WriteLine(hits.Doc(i).GetField("name").StringValue());
            }
        }

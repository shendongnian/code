    using System;
    using System.Collections;
    using Lucene.Net.Analysis;
    using Lucene.Net.Documents;
    using Lucene.Net.Index;
    using Lucene.Net.Search;
    using Lucene.Net.Store;
    
    class Program
    {
        static void Main(string[] args)
        {
            Directory index = new RAMDirectory();
            Analyzer analyzer = new KeywordAnalyzer();
            IndexWriter writer = new IndexWriter(index, analyzer, true);
            Document doc = new Document();
            doc.Add(new Field("title", "t1", Field.Store.YES, 
                Field.Index.TOKENIZED));
            writer.AddDocument(doc);
            doc = new Document();
            doc.Add(new Field("title", "t2", Field.Store.YES, 
                Field.Index.TOKENIZED));
            writer.AddDocument(doc);
            
            writer.Close();
            
            Searcher searcher = new IndexSearcher(index);
            Query query = new MatchAllDocsQuery();
            Filter filter = new LuceneCustomFilter();
            Sort sort = new Sort("title", true);
            Hits hits = searcher.Search(query, filter, sort);
            IEnumerator hitsEnumerator = hits.Iterator();
            while (hitsEnumerator.MoveNext())
            {
                Hit hit = (Hit)hitsEnumerator.Current;
                Console.WriteLine(hit.GetDocument().GetField("title").
                    StringValue());
            }
        }
    }
    public class LuceneCustomFilter : Filter
    {
        public override BitArray Bits(IndexReader indexReader)
        {
            BitArray bitarray = new BitArray(indexReader.MaxDoc());
            int[] docs = new int[1];
            int[] freq = new int[1];
            TermDocs termDocs = indexReader.TermDocs(
                    new Term(@"title", "t1"));
            int count = termDocs.Read(docs, freq);
            if (count == 1)
            {
                bitarray.Set(docs[0], true);
            }
            return bitarray;
        }
    }

    using System;
        using System.Collections.Generic;
        namespace Wrox.ProCSharp.Generics
        {
        public class DocumentManager < T >
        {
        private readonly Queue < T > documentQueue = new Queue < T > ();
        public void AddDocument(T doc)
        {
        lock (this)
        {
        documentQueue.Enqueue(doc);
        }
        }
        public bool IsDocumentAvailable
        {
        get { return documentQueue.Count > 0; }
        }
        }
        }

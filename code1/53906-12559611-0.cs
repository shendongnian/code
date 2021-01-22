                writer = new IndexWriter(directory, new StandardAnalyzer(), IndexWriter.MaxFieldLength.UNLIMITED);
            }
            catch (LockObtainFailedException ex)
            {
                DirectoryInfo indexDirInfo = new DirectoryInfo(directory);
                FSDirectory indexFSDir = FSDirectory.Open(indexDirInfo, new Lucene.Net.Store.SimpleFSLockFactory(indexDirInfo));
                IndexWriter.Unlock(indexFSDir);
                writer = new IndexWriter(directory, new StandardAnalyzer(), IndexWriter.MaxFieldLength.UNLIMITED);
            }

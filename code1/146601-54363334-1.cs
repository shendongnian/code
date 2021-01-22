        public static void SetupDataReader(this Mock<IDataReader> dataReaderMock, IList<string> columnNames, ICollection collection)
        {
            var queue = new Queue(collection);
            dataReaderMock
                .Setup(x => x.Read())
                .Returns(() => queue.Count > 0)
                .Callback(() =>
                {
                    if (queue.Count > 0)
                    {
                        var row = queue.Dequeue();
                        foreach (var columnName in columnNames)
                        {
                            var columnValue = row.GetType().GetProperty(columnName).GetValue(row);
                            dataReaderMock
                                .Setup(x => x[columnNames.IndexOf(columnName)])
                                .Returns(columnValue);
                            dataReaderMock
                                .Setup(x => x[columnName])
                                .Returns(columnValue);
                        }
                    }
                });
        }

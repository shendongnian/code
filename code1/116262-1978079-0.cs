        public class Order
        {
            public int ID { get; set; }
            public int Created { get; set; }
            public List<Item> Items { get; set; }
        }
        public class Item
        {
            public string Sku { get; set; }
            public int Quantity { get; set; }
        }
        public class OrderCsvBuilder
        {
            private readonly StringBuilder m_CsvData = new StringBuilder();
            // constructor accepts a sequence or Orders
            public OrderCsvBuilder(IEnumerable<Order> orders)
            {
                foreach (var order in orders)
                    WriteOrder(order);
            }
            // returns the formatted CSV data as a string
            public string GetCsvData()
            {
                return m_CsvData.ToString();
            }
            // writes a single order and its line items to csv format
            private void WriteOrder( Order order )
            {
                WriteCsvFields( false, order.ID, order.Created );
                var itemIndex = 0;
                foreach( var item in order.Items )
                    WriteOrderItem( item, itemIndex++ );
            }
            // writes a single order item to csv format
            private void WriteOrderItem( Item item, int itemIndex )
            {
                // write the extra fields when the order item is not the first item
                if( itemIndex > 0 )
                    WriteCsvFields( false, string.Empty, string.Empty );
                // use (?:) to append indicator of whether item is first or additional
                WriteCsvFields( true, item.Quantity, item.Sku, itemIndex > 0 ? "Y" : "N" );
            }
            // writes a series of fields to the file in csv form
            private void WriteCsvFields( bool isLineEnd, params object[] fields )
            {
                // write each field to the StringBuilder in CSV format
                // TODO: Need better error handling and escaping of special characters
                foreach( var field in fields )
                {
                    m_CsvData.AppendFormat("\"{0}\", ", field);
                }
                // trim extra trailing space and comma if this is the last item of a line
                if( isLineEnd )
                    m_CsvData.Remove(m_CsvData.Length - 2, 2);
            }
        }

    public class Data
    {
        public string Text { get; set; }
    }
    public IEnumerable<string> GetData(string id)
    {
        return  _context.TableData
                        .Where(r => r.ID == id)
                        .Select (r => new Data { Text = r.Name });
    }

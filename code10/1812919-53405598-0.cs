        private IHostingEnvironment _hostingEnvironment; // injected by DI
        private AppDbContext _dbContext;                 // injected by DI
        
        public IActionResult OnPostSave(){
            var sheet = this.ParseSheetFromRequest(false);
            var records = this.ParseDocsFromSheet(sheet);
            var sb = this.BuildTableHtml(records);
            // typically, we'll use Database to generate the Id
            //     as we cannot trust user 
            foreach (var record in records) {
                record.Id = default(int);  
            }
            this._dbContext.ImportDocs.AddRange(records);
            this._dbContext.SaveChanges();
            return this.Content(sb==null?"":sb.ToString());
        }
        public IActionResult OnPostImport(){
            var sheet = this.ParseSheetFromRequest(true);
            var records = this.ParseDocsFromSheet(sheet);
            var sb = this.BuildTableHtml(records);
            return this.Content(sb==null?"":sb.ToString());
        }
        private ISheet ParseSheetFromRequest(bool saveFile) { 
            // ...
        }
        
        private List<ImportDocs> ParseDocsFromSheet(ISheet sheet){
            // ...
        }
        private StringBuilder BuildTableHtml<T>(IList<T> records){   
            // ...
        }

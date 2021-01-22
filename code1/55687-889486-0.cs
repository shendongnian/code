    /// <summary>
    /// Worker class that collects comments from a Word document and exports them as ReviewItems
    /// </summary>
    internal class ReviewItemCollector
    {
        /// <summary>
        /// Working document
        /// </summary>
        private Word.Document WorkingDoc = new Word.DocumentClass();
        /// <summary>
        /// Extracts the review results from a Word document
        /// </summary>
        /// <param name="fileName">Fully qualified path of the file to be evaluated</param>
        /// <returns></returns>
        public ReviewResult GetReviewResults(string fileName)
        {
            Word.Application wordApp = null;
            List<ReviewItem> reviewItems = new List<ReviewItem>();
            object missing = System.Reflection.Missing.Value;
            try
            {
                // Fire up Word
                wordApp = new Word.ApplicationClass();
                // Some object variables because the Word API requires this
                object fileNameForWord = fileName;
                object readOnly = true;
                WorkingDoc = wordApp.Documents.Open(ref fileNameForWord,
                    ref missing, ref readOnly,
                    ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing);
                // Gather all paragraphs that are chapter headers, sorted by their start position
                var headers = (from Word.Paragraph p in WorkingDoc.Paragraphs
                               where IsHeading(p)
                               select new Heading()
                               {
                                   Text = GetHeading(p),
                                   Start = p.Range.Start
                               }).ToList().OrderBy(h => h.Start);
                reviewItems.AddRange(FindComments(headers));
                // I will be doing similar things with Revisions in the document
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString(), 
                    "Error while collecting review items", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (wordApp != null)
                {
                    object doNotSave = Word.WdSaveOptions.wdDoNotSaveChanges;
                    wordApp.Quit(ref doNotSave, ref missing, ref missing);
                }
            }
            ReviewResult result = new ReviewResult();
            result.Items = reviewItems.OrderBy(i => i.Position);
            return result;
        }
        /// <summary>
        /// Finds all comments in the document and converts them to review items
        /// </summary>
        /// <returns>List of ReviewItems generated from comments</returns>
        private List<ReviewItem> FindComments(IOrderedEnumerable<Heading> headers)
        {
            List<ReviewItem> result = new List<ReviewItem>();
            // Generate ReviewItems from the comments in the documents
            var reviewItems = from Word.Comment c in WorkingDoc.Comments
                              select new ReviewItem()
                              {
                                  Position = c.Scope.Start,
                                  Page = GetPageNumberOfRange(c.Scope),
                                  Paragraph = GetHeaderForRange(headers, c.Scope),
                                  Description = c.Range.Text,
                                  ItemType = DetermineCommentType(c)
                              };
            return reviewItems.ToList();
        }
        /// <summary>
        /// Brute force translation of comment type based on the contents...
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private static string DetermineCommentType(Word.Comment c)
        {
            // This code is very specific to my solution, might be made more flexible/configurable
            // For now, this works :-)
            string text = c.Range.Text.ToLower();
            if (text.EndsWith("?"))
            {
                return "Vraag";
            }
            if (text.Contains("spelling") || text.Contains("spelfout"))
            {
                return "Spelling";
            }
            if (text.Contains("typfout") || text.Contains("typefout"))
            {
                return "Typefout";
            }
            if (text.ToLower().Contains("omissie"))
            {
                return "Omissie";
            }
            return "Opmerking";
        }
        /// <summary>
        /// Determine the last header before the given range's start position. That would be the chapter the range is part of.
        /// </summary>
        /// <param name="headings">List of headings as identified in the document.</param>
        /// <param name="range">The current range</param>
        /// <returns></returns>
        private static string GetHeaderForRange(IEnumerable<Heading> headings, Word.Range range)
        {
            var found = (from h in headings
                         where h.Start <= range.Start
                         select h).LastOrDefault();
            if (found != null)
            {
                return found.Text;
            }
            return "Unknown";
        }
        /// <summary>
        /// Identifies whether a paragraph is a heading, based on its styling.
        /// Note: the documents we're reviewing are always in a certain format, we can assume that headers
        /// have a style named "Heading..." or "Kop..."
        /// </summary>
        /// <param name="paragraph">The paragraph to be evaluated.</param>
        /// <returns></returns>
        private static bool IsHeading(Word.Paragraph paragraph)
        {
            Word.Style style = paragraph.get_Style() as Word.Style;
            return (style != null && style.NameLocal.StartsWith("Heading") || style.NameLocal.StartsWith("Kop"));
        }
        /// <summary>
        /// Translates a paragraph into the form we want to see: preferably the chapter/paragraph number, otherwise the
        /// title itself will do.
        /// </summary>
        /// <param name="paragraph">The paragraph to be translated</param>
        /// <returns></returns>
        private static string GetHeading(Word.Paragraph paragraph)
        {
            string heading = "";
            // Try to get the list number, otherwise just take the entire heading text
            heading = paragraph.Range.ListFormat.ListString;
            if (string.IsNullOrEmpty(heading))
            {
                heading = paragraph.Range.Text;
                heading = Regex.Replace(heading, "\\s+$", "");
            }
            return heading;
        }
        /// <summary>
        /// Determines the pagenumber of a range.
        /// </summary>
        /// <param name="range">The range to be located.</param>
        /// <returns></returns>
        private static int GetPageNumberOfRange(Word.Range range)
        {
            return (int)range.get_Information(Word.WdInformation.wdActiveEndPageNumber);
        }
    }

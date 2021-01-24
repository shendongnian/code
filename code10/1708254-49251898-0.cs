        /// <summary>
        /// Generates the text for an inline comment
        /// </summary>
        /// <returns>The text for an inline comment</returns>
        public string Comment()
        {
            //Get Selection
            var objSel = (TextSelection)_dte2.ActiveDocument.Selection;
            //Create EditPoint
            var editPoint = objSel.TopPoint.CreateEditPoint();
            editPoint.StartOfLine();
            //Get active document
            var activeDoc = _dte2.ActiveDocument.Object() as TextDocument;
            //Get text between EditPoint and Selection
            var text = activeDoc.CreateEditPoint(editPoint).GetText(objSel.TopPoint);
            
            //return text
            return text.Contains("//") ? $" {GetText()} : " : $"// {GetText()} : ";
        }

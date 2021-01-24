      private void FreezeButton()
        {
            var sb = new StringBuilder();
            sb.Append("if (typeof(Page_ClientValidate) == 'function') { ");
            sb.Append("var oldPage_IsValid = Page_IsValid; var oldPage_BlockSubmit = Page_BlockSubmit;");
            sb.Append("if (Page_ClientValidate('" + btnAdd.ValidationGroup + "') == false) {");
            sb.Append(" Page_IsValid = oldPage_IsValid; Page_BlockSubmit = oldPage_BlockSubmit; return false; }} ");
            sb.Append("this.value = 'Processing...';");
            sb.Append("this.disabled = true;");
            sb.Append(Page.ClientScript.GetPostBackEventReference(btnAdd, null) + ";");
            sb.Append("return true;");
            string submitButtonOnclickJs = sb.ToString();
            btnAddReceipt.Attributes.Add("onclick", submitButtonOnclickJs);
        }

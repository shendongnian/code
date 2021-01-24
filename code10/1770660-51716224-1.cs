    <script type="text/javascript">
        @if (!ViewContext.ViewData.ModelState.IsValid)
    {
        var sb = new System.Text.StringBuilder();
        foreach (var modelState in ViewContext.ViewData.ModelState.Values)
        {
            foreach (var error in modelState.Errors)
            {
                sb.Append(error.ErrorMessage);
            }
        }
        @:alert('@sb.ToString()');
    }
    </script>

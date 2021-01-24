    @using Data.Utilities
    @{
        var text = TempData[Constants.Common.ModalMessage];
        if (text != null && !text.Equals(string.Empty))
        {
            <script type="text/javascript">
                showDefaultModal("@text");
            </script>
        }
    }

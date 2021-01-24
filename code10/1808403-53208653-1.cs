    [HttpPost]
    public IActionResult Filter(FilterViewModel viewModel) {
       bool isChecked = viewModel.DoApplyAppleFilter;
       // ...
    }

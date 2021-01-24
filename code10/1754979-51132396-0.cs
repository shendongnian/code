    for (int i = 0; i < _viewModel.SingleEmployee.Group.Rights.Count; i++)
    {
        if (_viewModel.SingleEmployee.Group.Rights[i].HasRight != _viewModel.RightsCollection[i].HasRight)
        {
            _viewModel.RightsCollection[i].HasRight = _viewModel.SingleEmployee.Group.Rights[i].HasRight;
        }
    }

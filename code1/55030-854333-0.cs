    IQueryable<Order> query = ...
    if (!string.IsNullOrEmpty(txtName.Text.Length)) {
      //add it to the function
      query = query.Where(a => a.Name.StartsWith(txtName.Text));
    }
    if (!string.IsNullOrEmpty(txtType.Text.Length)) {
      //add it to the function
      query = query.Where(a => a.Type == txtType.Text);
    }

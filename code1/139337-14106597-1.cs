    // dataGridView1
    this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
      this.nameDataGridViewTextBoxColumn,
      this.valueDataGridViewTextBoxColumn});
    this.dataGridView1.DataSource = this.bindingSource1;
    // bindingSource1
    this.bindingSource1.DataSource = typeof(SomeNamespace.DataObject);
    // valueListBindingSource
    this.valueListBindingSource.DataMember = "ValueList";
    this.valueListBindingSource.DataSource = this.bindingSource1;
    // nameDataGridViewTextBoxColumn
    this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
    // valueDataGridViewTextBoxColumn
    this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
    this.valueDataGridViewTextBoxColumn.DataSource = this.valueListBindingSource;

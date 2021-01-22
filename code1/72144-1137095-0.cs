StringBuilder sb = new StringBuilder()
for (int i = 0; i &lt; listbox.Items.Count; i++) {
  if (!listbox.Items[i].Selected) {
    continue;
  }
  if (sb.Length > 0) {
    sb.Append(" and ");
  }
  sb.AppendFormat("[{0}] = {1}", listbox.Items[i].Text, ddl.SelectedItem);
}
dv.RowFilter = sb.ToString();

void OnCheckedChanged()
{
     bool showMammals = radioButton.IsChecked;
     this.lcv.Filter = new Predicate<object>((p) => (p as Animal).IsMammal == showMammals);
     this.lcv.Refresh();
}
</pre>

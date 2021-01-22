    [Test] public void ShouldCopyFromAvailableToSelectedWhenAddButtonIsCLicked(){
      myForm.AvailableList.Items.Add("red");
      myForm.AvailableList.Items.Add("yellow");
      myForm.AvailableList.Items.Add("blue");
    
      myForm.AvailableList.SelectedIndex = 1;
      myForm.AddButton.Click();
      
      Assert.That(myForm.AvaiableList.Items.Count, Is.EqualTo(2));
      Assert.That(myForm.SelectedList.Items[0], Is.EqualTo("yellow"));
    }

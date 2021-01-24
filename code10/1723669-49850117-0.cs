    private void MyButton_Click(object sender, EventArgs e)
    {
      buttonTcs.SetResult(5);
    }
    
    private async void MyForm_Shown(object sender, EventArgs e)
    {
      var buttonData = await buttonTcs.Task;
    
      // now if the program reaches this line, it means that we can use the ButtonData.    });
    }

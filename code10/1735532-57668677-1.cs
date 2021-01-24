     private ElementReference textToEdit;
     protected override Task OnAfterRenderAsync()
      {
          return javascriptRuntime.InvokeAsync<int>("hintCodeMirrorIntegration.initialize", textToEdit,
              Context.CurrentAsset.MimeType);
      }
    private async Task Save()
    {
        var code = await javascriptRuntime.InvokeAsync<string>("hintCodeMirrorIntegration.getCode", textToEdit);
        //... save the result in the database
    }

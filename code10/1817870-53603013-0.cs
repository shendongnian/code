    public override Task<DialogTurnResult> ContinueDialogAsync(DialogContext outerDc, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (_createAContactChoice.Synonyms.Select(s => s.ToLower()).Contains(outerDc.Context.Activity.Text?.ToLower()))
            {
                return outerDc.ReplaceDialogAsync(nameof(CreateContactDialog), null, cancellationToken);
            }
            return base.ContinueDialogAsync(outerDc, cancellationToken);
        }

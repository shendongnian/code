    Font font = new Font(tvQuestionSequence.Font, FontStyle.Bold);
    foreach (QuestionnaireBuilder_Category cat in categories)
    {
        TreeNode node = new TreeNode();
        node.Text = cat.Description;
        node.Name = cat.Id.ToString();
        node.NodeFont = font;
        tvQuestionSequence.BeginUpdate();  //added newline here  <--
        tvQuestionSequence.Nodes.Add(node);
        tvQuestionSequence.EndUpdate();  //added newline here <--
    }

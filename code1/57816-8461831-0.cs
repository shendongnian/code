    public static MessageBoxResult ShowQuestionYesNo(string message)
            {
                POLMessageBox w = new POLMessageBox("سوال", MessageBoxType.QuestionYesNo, message);
                w.ShowDialog();
                var b = w.DialogResult;
                if (b == true) return MessageBoxResult.Yes;
                if (b == false) return MessageBoxResult.No;
                return MessageBoxResult.No;
            }

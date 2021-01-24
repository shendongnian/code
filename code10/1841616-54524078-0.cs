        double gradebook,
            article,
            homework,
            practice,
            total,
         
                
            IndividualRate = .40,
            ArticleRate = .10,
            HomeworkRate = .25,
            PracticeRate = .25,
            individualamt ,
            articleamt,
            homeworkamt,
            practiceamt;
        gradebook = Convert.ToDouble(txtindividualproject.Text);
        homework = Convert.ToDouble(txtHomeworkAssignements.Text);
        article = Convert.ToDouble(txtArticleReview.Text);
        practice = Convert.ToDouble(txtPracticeAssignment.Text);
        individualamt = gradebook * IndividualRate;
        articleamt = article * ArticleRate;
        homeworkamt = homework * HomeworkRate;
        practiceamt = practice * PracticeRate;
        total = individualamt + articleamt + homeworkamt + practiceamt;
        
        lbltotal.Visible = true;
        lbltotal.Text = total.ToString("c");
        
        
    }

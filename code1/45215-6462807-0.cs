        mSqlDataSource.Selected += new sqlDataSourceStatusEventHandler(mSqlDataSource_Selected);
        void mSqlDataSource_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {
            if (e.Exception != null)
            {
                mErrorText.Text = e.Exception.Message;
                mErrorText.Visible = true;
                e.ExceptionHandled = true;
            }
        }

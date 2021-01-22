    for (int i = 0; i < comments.Count; i++)
				{
					controls.Comment commentCtrl = (controls.Comment)Page.LoadControl("~/userControls/Comment.ascx");
					commentCtrl.ID = "commentUserCtrl" + i;
					commentCtrl.setComment((myCommentObj)comments[i]);
					placeHolderComments.Controls.Add(commentCtrl);
				}

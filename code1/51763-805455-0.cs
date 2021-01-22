               private delegate void UpdateDelegate();
       void workflowRuntime_WorkflowIdled(object sender, WorkflowEventArgs e)
            {
                StateMachineWorkflowInstance stateMachineInstance = new StateMachineWorkflowInstance(MyManager.WorkflowRuntime, MyInstance.Id);
                UpdateDelegate LclUpdateDelgate = delegate()
                {
                    // Update the workflow state on the form thread
                    if (stateMachineInstance.CurrentState != null)
                        LabelWorkflowState.Text = stateMachineInstance.CurrentStateName;
                    else
                        LabelWorkflowState.Text = "";
                    
                };
                this.Invoke(LclUpdateDelgate);
            }

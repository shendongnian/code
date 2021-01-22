       [Fact]
        public void FilesRenameViewModel_Rename_Apply_Execute_Verify_NotifyPropertyChanged_If_Succeeded_Through_Extension_Test()
        {
            //  Arrange
            _filesViewModel.FolderPath = ConstFolderFakeName;
            _filesViewModel.OldNameToReplace = "Testing";
            //After the command's execution OnPropertyChanged for _filesViewModel.AllFilesFiltered should be raised
            _filesViewModel.NotifyPropertyChangedVerificationSettingUp(nameof(_filesViewModel.AllFilesFiltered));
            //Act
            _filesViewModel.ApplyRenamingCommand.Execute(null);
            // Assert
            Assert.True(_filesViewModel.IsNotifyPropertyChangedFired());
        }

       var parentDiv = GetParentByTagName("div", srcChild);
       var parentNodeTable = parentDiv.previousSibling;
       
       if(parentNodeTable)
        {
            var checkUncheckSwitch;
            
            if(check) //checkbox checked
            {
                var isAllSiblingsChecked = AreAllSiblingsChecked(srcChild);
                if(isAllSiblingsChecked)
                    checkUncheckSwitch = true;
                else    
                    return; //do not need to check parent if any(one or more) child not checked
            }
            else //checkbox unchecked
            {
                checkUncheckSwitch = false;
            }
            
            var inpElemsInParentTable = parentNodeTable.getElementsByTagName("input");
            if(inpElemsInParentTable.length > 0)
            {
                var parentNodeChkBox = inpElemsInParentTable[0]; 
                parentNodeChkBox.checked = checkUncheckSwitch; 
                //do the same recursively
                CheckUncheckParents(parentNodeChkBox, checkUncheckSwitch);
            }
        }

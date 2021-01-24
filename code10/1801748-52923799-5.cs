    <script src="~/js/app.bundle.js"></script>
    <script>
        var ES6Lib= OurLibrary.default;
        var userName = '@Model.UserName'; // from server = 'Jesse'
        var myClass = new ES6Lib(userName); // pass in a parameter
        var greeting = myClass.getData(); // run a function
    
        console.log(greeting); // prints 'Hello there, Jesse!'
        
        console.log(OurLibrary.answer()); // prints 42
    </script>
